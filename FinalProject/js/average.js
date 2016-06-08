/*變成8*8後計算畫素的灰度平均值*/
function Average(vimgData){
        var count = 0;
        for(var i = 0; i < vimgData.length; i++){
            count += vimgData[i];
        }
        return Math.round(count / vimgData.length);
},