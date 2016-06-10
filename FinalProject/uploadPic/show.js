var firebaseRef = 'https://informationrf.firebaseio.com/'; //firebase的路徑

$(function() {
    // var idx = window.location.href.indexOf('#');
    // var hash = (idx > 0) ? window.location.href.slice(idx + 1) : '';
    // if (hash === '') {
    //     // No hash found, so render the file upload button.
    //     $('#file-upload').show();
    //     document.getElementById("file-upload").addEventListener('change', handleFileSelect, false);
    // } else {
        // A hash was passed in, so let's retrieve and render it.
        // spinner.spin(document.getElementById('spin'));
        var f = new Firebase(firebaseRef + 'pics/' + '1' + '/filePayload');
        f.once('value', function(snap) {
            var payload = snap.val();
            console.log(payload);
            if (payload != null) {
                document.getElementById("pic").src = payload;
            } else {
                $('#body').append("Not found");
            }
            // spinner.stop();
        });
    // }
});
