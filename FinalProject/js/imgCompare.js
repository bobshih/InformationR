function imgCompare(imgData1,imgData2){
  var diff=(imgData1.data.length/4);
  console.log(diff);
      for (var i = 0; i < imgData1.data.length; i += 4) {
          if(imgData1.data[i]!=imgData2.data[i])
              diff--;
      }
      return diff/(imgData1.data.length/4)*100;
}
