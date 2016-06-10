var dropZone=$("#dropZone");
var dropImg=$("#dropImg")[0];
var dropZone2=$("#dropZone2");
var dropImg2=$("#dropImg2")[0];
var dropCanvas=document.createElement("canvas");
var dropCtx=dropCanvas.getContext("2d");
var imgPicker=$("#imgPicker");
var n=document.getElementById("selector").value;
$("#selector").on("change",function(event){ n=document.getElementById("selector").value;doSomething();});
imgPicker.on("change", function(event) {openFile(event);});

dropZone.on("drop", function(event) {
    event.preventDefault();
    event.stopPropagation();
    var files  = event.originalEvent.dataTransfer ; //擷取拖曳的檔案
    console.log(files.getData("text/plain"));
    dropImg.src=files.getData("text/plain");

});

dropImg.onload=function(){
  this.width=8;
  this.height=8;
  console.log(this.width+"+"+this.height);
      imgToPrint(this);
      doSomething();
}

function doSomething(){
  dropCanvas.width = dropImg.width;
  dropCanvas.height = dropImg.height;

  dropCtx.drawImage(dropImg, 0, 0, dropCanvas.width, dropCanvas.height);
  var dropImgData= dropCtx.getImageData(0, 0, dropCanvas.width, dropCanvas.height);
  ctx.putImageData(toGray(dropImgData, n), 0, 0);
  var grayData=[];
  var av=0;
  for(var i=0;i<dropImgData.data.length;i+=4){
    grayData.push(dropImgData.data[i]);
    av+=dropImgData.data[i];
  }
  av/=dropImgData.data.length/4;
  $("#similarity").html(thresholdMap(grayData,av).toString(2));
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
