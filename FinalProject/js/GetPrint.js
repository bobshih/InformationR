var firebaseRef = 'https://informationrf.firebaseio.com/'; //firebase的路徑

var prints = [];

var GetCategoryPrints = function(cName) {
    var firebase = new Firebase(firebaseRef + cName + "/print");
    firebase.once("value", function(ps) {
        ps.forEach(function(p) {
            var print = {};
            print.cName = cName;
            print.id = p.key();
            print.p = p.val();
            // console.log(print);
            prints.push(print);

        });
        fireBaseFlag--;
        // console.log("get prints");
        // console.log(prints);
        if (!fireBaseFlag) {
            $("#imgPicker").attr("disabled", false);
            $('#done').text("done");
        }
    });
}
$("#imgPicker").attr("disabled", true);
var fireBaseFlag;

var GetPrints = function() {
    var firebase = new Firebase(firebaseRef + "category");

    firebase.once('value', function(categories) {
        fireBaseFlag = categories.length;
        categories.forEach(function(category) {
            var c = category.key();
            GetCategoryPrints(c);
        });
    });

}

var GetImage = function(type, id) {
    // console.log("in get image type = " + type + " id = " + id);
    var f = new Firebase(firebaseRef + type + '/orgin/' + id);
    f.on('value', function(snapshot) {
        // console.log("firebase = " + f.toString());
        // console.log(snapshot.val());
        // return snapshot.val();
        var vimg = document.createElement("img");
        vimg.width = 80;
        vimg.height = 80;
        vimg.src = snapshot.val();
        vimg.onload = function() {
            imgBuffer.push(vimg);
            imgFlag--;
            if (!imgFlag) {
                imgPrint();
            }
        };
    });

}

// $(document).ready(GetPrints);
// $(document).ready(GetImage("test1", 1));
