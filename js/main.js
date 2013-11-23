/**
 * Created by krishnas on 11/12/13.
 */
(function(global, $){
    $("#navToPhotos").click(function(e) {
       $("#main-content-container").load("ajax-gallery1.html");
    });
})(window, window.jQuery);
