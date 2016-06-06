// var testImg=$("#testImg");
var testImg = document.createElement("img");
testImg.src = "src/testIMG.jpg";
var width=testImg.width;
var height=testImg.height;
var canvas=$("#canvas")[0];
canvas.width=width;
canvas.height=height;
var ctx = canvas.getContext("2d");
ctx.drawImage(testImg, 0, 0, width, height);
var imgData=ctx.getImageData(0,0,canvas.width,canvas.height);
for (var i=0;i<imgData.data.length;i+=4)
  {
  imgData.data[i]=255-imgData.data[i];
  imgData.data[i+1]=255-imgData.data[i+1];
  imgData.data[i+2]=255-imgData.data[i+2];
  imgData.data[i+3]=255;
  }
ctx.putImageData(imgData,0,0);
