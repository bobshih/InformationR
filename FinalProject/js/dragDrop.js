var dropZone=$("#dropZone");
var dropImg=$("#dropImg")[0];
var dropCanvas=document.createElement("canvas");
var dropCtx=dropCanvas.getContext("2d");
var imgPicker=$("#imgPicker");
imgPicker.on("change", function(event) {openFile(event);});

dropZone.on("drop", function(event) {
    event.preventDefault();
    event.stopPropagation();
    var files  = event.originalEvent.dataTransfer ; //擷取拖曳的檔案
    console.log(files.getData("text/plain"));
    dropImg.src=files.getData("text/plain");

});

dropImg.onload=function(){
      doSomething();
}

function doSomething(){
  var n;
  n=document.getElementById("selector").value;
  dropCanvas.width = dropImg.width;
  dropCanvas.height = dropImg.height;
  dropCtx.drawImage(dropImg, 0, 0, dropCanvas.width, dropCanvas.height);
  var dropImgData= dropCtx.getImageData(0, 0, dropCanvas.width, dropCanvas.height);
<<<<<<< HEAD
  ctx.putImageData(toGray(dropImgData, 3), 0, 0);
  $("#similarity").html(imgCompare(imgData,dropImgData));
=======
  ctx.putImageData(toGray(dropImgData, n), 0, 0);
>>>>>>> 4dc2802a4c720b88cc417c3ddc3dfbd67d284d21
}

var openFile = function(event) {
    var input = event.target;
    var reader = new FileReader();
    reader.onload = function(){
      var dataURL = reader.result;
      dropImg.src = dataURL;
    };
    reader.readAsDataURL(input.files[0]);
  };

$("html").on("dragover", function(event) {
    event.preventDefault();
    event.stopPropagation();
});

$("html").on("dragleave", function(event) {
    event.preventDefault();
    event.stopPropagation();
});
$("html").on("drop", function(event) {
    event.preventDefault();
    event.stopPropagation();
});
