var dropZone=$("#dropZone");
var dropImg=$("#dropImg")[0];

dropZone.on("drop", function(event) {
    event.preventDefault();
    event.stopPropagation();
    var files  = event.originalEvent.dataTransfer ; //擷取拖曳的檔案
    console.log(files.getData("text/plain"));
    dropImg.src=files.getData("text/plain");
});


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
