// var testImg=$("#testImg");
var testImg = document.createElement("img");
$(testImg).appendTo("body");
testImg.src = "src/testIMG.jpg";

var width = testImg.width;
var height = testImg.height;
var canvas = $("#canvas")[0];

var ctx = canvas.getContext("2d");
var imgData = ctx.getImageData(0, 0, canvas.width, canvas.height);


// ctx.putImageData(toGray(imgData, 3), 0, 0);
testImg.onload = function() {
  AutoResizeImage(80,80,this);
  canvas.width = testImg.width;
  canvas.height = testImg.height;
  ctx.drawImage(testImg, 0, 0, testImg.width, testImg.height);
  imgData = ctx.getImageData(0, 0, canvas.width, canvas.height);
  console.log(imgColorIdentify(colorUpsidedown(imgData)));
};

function colorUpsidedown(vimgData) {
    for (var i = 0; i < vimgData.data.length; i += 4) {
        vimgData.data[i] = 255 - vimgData.data[i];
        vimgData.data[i + 1] = 255 - vimgData.data[i + 1];
        vimgData.data[i + 2] = 255 - vimgData.data[i + 2];
        vimgData.data[i + 3] = 255;
    }
    return vimgData;
}

//轉灰階
//參數(圖的data,灰階層數)
//回傳 轉換後的imgdata
function toGray(imgData, n) {
    var gap = (function() {
        var result = [];
        for (var i = 1; i < n; i++) {
            result.push(Math.ceil((i / n) * 255));
        }
        return result;
    })(); //臨界值
    var colors = (function() {
        var result = [];
        result.push(0);
        for (var i = 1; i < n - 1; i++) {
            result.push(Math.ceil((i / (n - 1)) * 255));
        }
        result.push(255);
        return result;
    })(); //灰色

    for (var i = 0; i < imgData.data.length; i += 4) {

        var level = 0;
        for (var gaps = 0; gaps < gap.length; gaps++) {
            if (imgData.data[i] > gap[gaps])
                level++;
        }

        imgData.data[i] = colors[level];
        imgData.data[i + 1] = colors[level];
        imgData.data[i + 2] = colors[level];
    }
    return imgData;
}

//圖的等比例縮小
//參數(寬,高,圖)
function AutoResizeImage(maxWidth, maxHeight, objImg) {
    var img = new Image();
    img.src = objImg.src;
    var hRatio;
    var wRatio;
    var Ratio = 1;
    var w = img.width;
    var h = img.height;
    wRatio = maxWidth / w;
    hRatio = maxHeight / h;
    if (maxWidth == 0 && maxHeight == 0) {
        Ratio = 1;
    } else if (maxWidth == 0) { //
        if (hRatio < 1) Ratio = hRatio;
    } else if (maxHeight == 0) {
        if (wRatio < 1) Ratio = wRatio;
    } else if (wRatio < 1 || hRatio < 1) {
        Ratio = (wRatio <= hRatio ? wRatio : hRatio);
    }
    if (Ratio < 1) {
        w = w * Ratio;
        h = h * Ratio;
    }
    objImg.height = h;
    objImg.width = w;
}

//顏色判斷
//參數(imgdata)
//回傳圖片是偏RGB中的哪個(1=R,2=G,3=B)
function imgColorIdentify(vimgData){
  var R=0;
  var G=0;
  var B=0;
  var total=vimgData.data.length/4;

  for (var i = 0; i < vimgData.data.length; i += 4) {
      if(vimgData.data[i] >=vimgData.data[i+1] &&vimgData.data[i] >=vimgData.data[i+2] )
      R++;
      else if(vimgData.data[i+1]>=vimgData.data[i+2])
      G++;
      else {
        B++;
      }
  }
  if(R>=G&&R>=B)
  return 1;
  else if(G>=B)
  return 2;
  else {
    return 3;
  }
}
