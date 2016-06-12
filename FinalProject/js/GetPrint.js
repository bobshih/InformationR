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

        console.log("get prints");
        console.log(prints);
    });
}

var GetPrints = function() {
    var firebase = new Firebase(firebaseRef + "category");
    firebase.once('value', function(categories) {
        categories.forEach(function(category) {
            var c = category.key();
            GetCategoryPrints(c);


        });
    });
}

var GetImage = function(type, id) {
    console.log("in get image type = " + type + " id = " + id);
    var f = new Firebase(firebaseRef + type + '/orgin/' + id);
    f.on('value', function(snapshot) {
        console.log("firebase = " + f.toString());
        document.getElementById("img").src = snapshot.val();
    });
}

// $(document).ready(GetPrints);
$(document).ready(GetImage("test1", 1));
