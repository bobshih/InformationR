function hamdist(s1, s2)
{ 
   /*如果兩張灰階圖變成的的字串長度不一樣,會說不行而警示*/
   if (s1.length != s2.length) {
      alert("Both sequence must be of the same length!");
      return -1;
   }
   /*開始計算兩組字串的Hamming distance,差距越大distance就越大,兩張圖就越不像*/
   var distance = 0;
   for(var i = 0; i < s1.length; i++)
      if (s1.charAt(i) != s2.charAt(i))
         distance++;
   return distance;
}