
/*此method是畫素灰度的平均值
剛剛算完的平均值傳入,將每個畫素的灰度,與平均值進行比較,大於或等於平均值,回傳1;小於平均值,回傳0
傳入的byteData變數就是每個畫素的灰度值*/
function thresholdMap(data, threshold){
            return mapToBits(data, function(byteData){
                return byteData >= threshold;
            });
        }



/*此method是計算雜湊值
將上一步的比較結果組合在一起即構成一個64位的整數(家文目前用80*80,此例用8*8所以是64位元)
(若用家文的壓縮method指定8*8那就應該是64位)保證所有圖片都採用同樣次序*/
/*這裡應該有做101011...00101這種2進位轉16進位的轉換,所以這段result |= callback(element) << bit++;
我想就應該是這步驟,也有可能就只是單純的變10101000110...*/
/*演算法上說這就是那張圖片的指紋(也可說是他的身分證)(接著還要比較這些指紋,用Hamming distance(完成),
    如果不相同的資料位不超過5就說明兩張圖片很相似；如果大於10,就說明這是兩張不同的圖片*/
function mapToBits(data, callback){
    var result = ""
    // var i=0;
    data.forEach(function(element){
      if(callback(element)){
        result="1"+result;
      }
      else{
        result="0"+result;
      }
        // console.log(i+"+"+callback(element)+"+"+result);
        // i++;
    });
    return result;
}
