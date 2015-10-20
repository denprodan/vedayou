$(document).ready(function () {
    $(".about_me_text").fitText(2.0, { minFontSize: '12px', maxFontSize: '16px' });
    $(".article_header_text").fitText(1.0, { minFontSize: '10px', maxFontSize: '18px' });
    $(".section_title_header_text_container").fitText(1.0, { minFontSize: '10px', maxFontSize: '20px' });
   

    var res = getInternetExplorerVersion();

    if (res < 0) return;

    $(".left_top_divider_ornament").css("visibility", "hidden");
    $(".right_top_divider_ornament").css("visibility", "hidden");
    $(".left_bottom_divider_ornament").css("visibility", "hidden");
    $(".right_bottom_divider_ornament").css("visibility", "hidden");
    $(".article_header_left_ornament").css("visibility", "hidden");
    $(".article_header_right_ornament").css("visibility", "hidden");
  
});

function getInternetExplorerVersion() {
    var rv = -1; // Return value assumes failure.

    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");

        if (re.exec(ua) != null) rv = parseFloat(RegExp.$1);
    }
    return rv;
}