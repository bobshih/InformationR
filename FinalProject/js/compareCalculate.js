
/*此method是比較畫素的灰度
剛剛算完的平均值傳入,將每個畫素的灰度,與平均值進行比較,大於或等於平均值,回傳TRUE;小於平均值,回傳FALSE*/
function thresholdMap(data, threshold){

    return mapToBits(data, isBiggerThanAverage(byteData));
}
function isBiggerThanAverage(byteData){
    return byteData >= threshold;
}


/*此method是計算雜湊值
將上一步的比較結果組合在一起即構成一個64位的整數
(若用家文的壓縮method指定8*8那就應該是64位)保證所有圖片都採用同樣次序*/
/*演算法上說這就是那張圖片的指紋(也可說是他的身分證)(接著還要比較這些指紋,這部分還沒做,之後用Hamming distance,
    如果不相同的資料位不超過5就說明兩張圖片很相似；如果大於10,就說明這是兩張不同的圖片*/
function mapToBits(data, callback){
    var result = 0, bit = 0;
    data.forEach(function(element){
        result |= callback(element) << bit++;
    });
    return result;
}
