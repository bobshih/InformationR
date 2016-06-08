
	function isColorSimilar(imgData1, imgData2){//傳入相同大小img即可比較
		var totalsimilar=0;
		var imgMaxLength=imgData1.data.length;
		if(imgData2.data.length<imgData1.data.length){//如果圖片大小不同先以小的長度為準,避免出錯
			imgMaxLength=imgData2.data.length;
		}
		if(typeof imgData1.data.length == 0){
			return false;
		}
		if(typeof imgData2.data.length == 0){
			return false;
		}
		for (var i = 0; i < imgMaxLength; i+=1) {        
			if(imgData1.data[i] === imgData2.data[i]){
				totalsimilar++;
			} else if ( Math.abs(imgData1.data[i] - imgData2.data[i]) < 16 ) {//顏色差如果小於16,視為相似(可調整)
				totalsimilar++;
			}        
  		}	
		return totalsimilar>(imgMaxLength/2);//如果圖片有一半以上的顏色相似,那就回傳TRUE(可調整)
	}
	