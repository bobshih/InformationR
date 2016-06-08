/*變成8*8後計算畫素的灰度平均值*/
function Average(data){
        var count = 0;
        for(var i = 0; i < data.length; i++){
            count += data[i];
        }
        return Math.round(count / data.length);
},