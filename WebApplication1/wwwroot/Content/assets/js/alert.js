type = ['', 'info', 'success', 'warning', 'danger'];

$().ready(function() {
    $sidebar = $('.sidebar');
    $sidebar_img_container = $sidebar.find('.sidebar-background');

    $full_page = $('.full-page');

    $sidebar_responsive = $('body > .navbar-collapse');

    window_width = $(window).width();

    if (window_width > 767) {
        if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
            $('.fixed-plugin .dropdown').addClass('open');
        }

    }   


});

demo = {
    initPickColor: function() {
        $('.pick-class-label').click(function() {
            var new_class = $(this).attr('new-class');
            var old_class = $('#display-buttons').attr('data-class');
            var display_div = $('#display-buttons');
            if (display_div.length) {
                var display_buttons = display_div.find('.btn');
                display_buttons.removeClass(old_class);
                display_buttons.addClass(new_class);
                display_div.attr('data-class', new_class);
            }
        });
    },      

    showSwal: function(type) {
        if (type == 'basic') {
            swal("Here's a message!");

        } else if (type == 'title-and-text') {
            swal("Here's a message!", "It's pretty, isn't it?");
        } else if (type == 'success-message') {
            swal("Good job!", "You clicked the button!", "success");
        } else if (type == 'warning-message-and-confirmation') {
            swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn btn-info btn-fill",
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonClass: "btn btn-danger btn-fill",
                    closeOnConfirm: false,
                }, function() {
                    swal("Deleted!", "Your imaginary file has been deleted.", "success");
                });

        } else if (type == 'warning-message-and-cancel') {
            swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonText: "No, cancel plx!",
                    closeOnConfirm: false,
                    closeOnCancel: false
                }, function(isConfirm) {
                    if (isConfirm) {
                        swal("Deleted!", "Your imaginary file has been deleted.", "success");
                    } else {
                        swal("Cancelled", "Your imaginary file is safe :)", "error");
                    }
                });

        } else if (type == 'custom-html') {
            swal({
                title: 'HTML example',
                html:
                    'You can use <b>bold text</b>, ' +
                        '<a href="http://github.com">links</a> ' +
                        'and other HTML tags'
            });

        } else if (type == 'auto-close') {
            swal({
                type: "warning",
                title: "Duplicate id",
                text: "Please enter your ID again.",
                timer: 1500,
                showConfirmButton: false
            });
        } else if (type == 'id-check') {
            swal({
                type: "warning",
                title: "Check your id",
                text: "Please check your id again.",
                timer: 1500,
                showConfirmButton: false
            });
        } else if (type == 'input-field') {
            swal({
                    title: 'Input something',
                    html: '<p><input id="input-field" class="form-control">',
                    showCancelButton: true,
                    closeOnConfirm: false,
                    allowOutsideClick: false
                },
                function() {
                    swal({
                        html:
                            'You entered: <strong>' +
                                $('#input-field').val() +
                                '</strong>'
                    });
                });
        }
    },
};