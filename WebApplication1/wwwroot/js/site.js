//네비게이션 초기화 함수
function initNavigation() {
    var url = location.href;

    var split_url = url.split('/');

    var split_url_len = split_url.length;

    var controller = split_url[split_url_len - 1]
    var page = split_url[split_url_len - 1].toLowerCase();

    switch (controller) {
        case "Company":
            $('#nav_company').addClass('sel_menu');           
            break;
        case "Product":
            $('#nav_product').addClass('sel_menu');        
            break;
        case "Technology":
            $('#nav_technology').addClass('sel_menu');
            break;
        case "Contact":
            $('#nav_contact').addClass('sel_menu');
            break;
        case "News":
            $('#nav_news').addClass('sel_menu');
            break;
        case "Language":
            $('#nav_lang').addClass('sel_menu');
            break;
    }
}
//분과 선택
$('.sel_depart').click(function () {
    $('.sel_depart').removeClass("sel");
    $(this).addClass("sel");

})

