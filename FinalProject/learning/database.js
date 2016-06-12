var ref = 'https://informationrf.firebaseio.com/'; //firebase的路徑

var existOrNot = 0;
var childNum = -1;

var testTag = function() {
    var type = document.getElementById('type').value;
    // var refTest = new Firebase("https://docs-examples.firebaseio.com/samplechat/users/fred");
    var firebase = new Firebase(ref);
    firebase.once("value", function(snapshot) {
        console.log("type = " + type);
        existOrNot = (snapshot.child(type).exists());
        console.log(existOrNot);
        document.getElementsByName('existLabel')[0].innerHTML = existOrNot;
        new Firebase(ref + type+"/orgin").once("value", function(snapshot) {
            childNum = snapshot.numChildren();
            document.getElementsByName('existLabel')[0].innerHTML += childNum;
        });

        // 設定新的類別，如果不存在的話
        if(existOrNot === false){
            new Firebase(ref+"category/" + type).set(type);
        }

        spinner.stop();
    });

}

var uploadFile = function(count) {
    var type = document.getElementById('type').value;
    console.log("in uploadFile");
    console.log("count = " + count);
    console.log("childNum = " + childNum);
    var id = (childNum + 1 + count);
    var newRef = ref + type + "/";

    // 存原圖片
    var firebase = new Firebase(newRef + "orgin/" + id);
    console.log(firebase.toString());
    var orgin = $('#' + count).attr("src");
    // console.log(orgin);
    firebase.set(orgin);

    //存指紋
    var firebase = new Firebase(newRef + "print/" + id);
    console.log(firebase.toString());
    var print = document.getElementsByName('print')[count].innerHTML;
    // var print = $("p[name='print']")[count].text();
    console.log(print);
    firebase.set(print);
}

var ClickUploadFiles = function(size) {
    var type = document.getElementById('type').value;
    console.log("size = " + size);
    console.log("type = " + type);
    console.log("existOrNot = " + existOrNot);

    for (var i = 0; i < size; i++) {
        uploadFile(i);
    }
    // var firebase = new Firebase(ref + type);
    // f.set(filePayload, function() {
    //     spinner.stop();
    //     document.getElementById("pano").src = e.target.result;
    //     $('#file-upload').hide();
    //     // Update the location bar so the URL can be shared with others
    //     window.location.hash = a;
    // });
    // firebase.once("value", function(snapshot) {
    //
    // });
    spinner.stop();
}
