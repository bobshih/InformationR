var spinner = new Spinner({
    color: 'black'
}); //建立Spinner物件

var toGray = function(imgData) {
    for (var i = 0; i < imgData.data.length; i += 4) {
        var avg = (imgData.data[i] + imgData.data[i + 1] + imgData.data[i + 2]) / 3;
        imgData.data[i] = avg;
        imgData.data[i + 1] = avg;
        imgData.data[i + 2] = avg;
    }
    return imgData;
}

var toPrint = function(imgID, li, i) {
    var img = document.getElementById(imgID);
    var can = document.createElement("canvas");
    var canCtx = can.getContext("2d");
    can.width = img.width;
    can.height = img.height;
    can.id = "c"+i;
    canCtx.drawImage(img, 0, 0, can.width, can.height);
    var iData = canCtx.getImageData(0, 0, can.width, can.height);
    canCtx.putImageData(toGray(iData), 0, 0);
    var grayData = [];
    var av = 0;
    for (var i = 0; i < iData.data.length; i += 4) {
        grayData.push(iData.data[i]);
        av += iData.data[i];
    }
    av /= iData.data.length / 4;
    li.append(can);
    li.append("<br>");

    var prints = thresholdMap(grayData, av).toString(2);
    var pPrints = $('<p name="print"></p>');
    pPrints.text(prints);
    li.append(pPrints);
    return prints;
}

var readFile = function(file, index) {
    var fileReader = new FileReader();
    fileReader.onload = function(file) {
        var li = $('<li></li>').appendTo($('#pics'));
        var image = $('<img class="img_small">');
        image.attr('id', index);
        image.attr('src', file.target.result);
        image.appendTo(li);
        // var image2 = $('<img>').attr('src', image.attr('src')).appendTo(li);
        // console.log(image);
        var print = toPrint(index, li, index);
        console.log(print);
    }

    fileReader.readAsDataURL(file);
}

var count = -1;

var main = function() {
    $('#spin').append(spinner);
    console.log("fsdf");
    $('#file-upload').on('change', function(){
        count = document.getElementById('file-upload').files.length;
    });
    $("#read_button").click(function() {
        var files = document.getElementById('file-upload').files;
        for (i = 0; i < count; i++) {
            readFile(files[i], i);
        }
    });

    $("#upload_button").click(function(){
        // console.log("click upload_button");
        spinner.spin(document.getElementById('spin'));
        ClickUploadFiles(count);
    });

    $("#testExist").click(function(){
        spinner.spin(document.getElementById('spin'));
        testTag();
    })
};

$(document).ready(main);
