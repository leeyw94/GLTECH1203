type = ['', 'info', 'success', 'warning', 'danger'];


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

    showNotification: function(from, align) {
        color = Math.floor((Math.random() * 4) + 1);

        $.notify({
                icon: "pe-7s-gift",
                message: "<b>Light Bootstrap Dashboard PRO</b> - forget about boring dashboards."
            }, {
                type: type[color],
                timer: 3000,
                placement: {
                    from: from,
                    align: align
                }
            });
    },
    initCharts: function() {

        /*  **************** 24 Hours Performance - single line ******************** */

        var dataPerformance = {
            labels: ['6pm', '9pm', '11pm', '2am', '4am', '8am', '2pm', '5pm', '8pm', '11pm', '4am'],
            series: [
                [1, 6, 8, 7, 4, 7, 8, 12, 16, 17, 14, 13]
            ]
        };

        var optionsPerformance = {
            showPoint: false,
            lineSmooth: true,
            height: "160px",
            axisX: {
                showGrid: false,
                showLabel: true
            },
            axisY: {
                offset: 40,
            },
            low: 0,
            high: 26
        };

        Chartist.Line('#chartPerformance', dataPerformance, optionsPerformance);


        /*  **************** NASDAQ: AAPL - single line with points ******************** */

        var dataStock = {
            labels: ['\'07', '\'08', '\'09', '\'10', '\'11', '\'12', '\'13', '\'14', '\'15'],
            series: [
                [22.20, 34.90, 42.28, 51.93, 62.21, 80.23, 62.21, 82.12, 102.50, 107.23]
            ]
        };

        var optionsStock = {
            lineSmooth: false,
            height: "160px",
            axisY: {
                offset: 40,
                labelInterpolationFnc: function(value) {
                    return '$' + value;
                }
            },
            low: 10,
            high: 110,
            classNames: {
                point: 'ct-point ct-white',
                line: 'ct-line ct-white'	           
            }
        };

        Chartist.Line('#chartStock', dataStock, optionsStock);	 
	

        /*  **************** Views  - barchart ******************** */

        var dataViews = {
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Mai', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            series: [
                [542, 443, 320, 780, 553, 453, 326, 434, 568, 610, 756, 895]
            ]
        };

        var optionsViews = {
            seriesBarDistance: 10,
            classNames: {
                bar: 'ct-bar ct-white'
            },
            axisX: {
                showGrid: false
            }
        };

        var responsiveOptionsViews = [
            ['screen and (max-width: 640px)', {
                seriesBarDistance: 5,
                axisX: {
                    labelInterpolationFnc: function(value) {
                        return value[0];
                    }
                }
            }]
        ];

        Chartist.Bar('#chartViews', dataViews, optionsViews, responsiveOptionsViews);


    },

  

    initAnimationsArea: function() {
        $('.animationsArea .btn').click(function() {
            animation_class = $(this).data('animation-class');

            $parent = $(this).closest('.animationsArea');

            $parent.find('.btn').removeClass('btn-fill');

            $(this).addClass('btn-fill');

            $parent.find('.animated')
                .removeAttr('class')
                .addClass('animated')
                .addClass(animation_class);

            $parent.siblings('.header').find('.title small').html('class: <code>animated ' + animation_class + '</code>');
        });
    },
    showSwal: function(type, _a, msg) {
        if (type == 'basic') {
            swal("Here's a message!");

        } else if (type == 'title-and-text') {
            swal("Here's a message!", "It's pretty, isn't it?");
        } else if (type == 'success-message') {



            swal("Good job!", "You clicked the button!", "success");
        }




        else if (type == 'warning-message-and-confirmation') {
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
                text: "Please enter your ID again. (Duplicate Email.)",
                timer: 1500,
                showConfirmButton: false
            });
        }
        else if (type == 'estimate') {
            swal({
                type: "warning",
                title: "Warning",
                text: "견적 정보가 존재하지 않습니다.",
                timer: 2500,
                showConfirmButton: false
            });
        } 
        else if (type == 'project_alert') {
            swal({
                type: "warning",
                title: "Warning",
                text: "프로젝트를 선택해주세요",
                timer: 2500,
                showConfirmButton: false
            });
        } 
        

        else if (type == 'alert') {
            swal({
                type: "warning",
                title: "Warning",
                text: msg,
                timer: 2500,
                showConfirmButton: false
            });
        }

        else if (type == 'itemName_alert') {
        swal({
        type: "warning",
        title: "Warning",
        text: "등록된 아이템이 없습니다.",
        timer: 2500,
        showConfirmButton: false
            });
        } 

        else if (type == 'id-check') {
            swal({
                type: "warning",
                title: "Check your id ",
                text: "E-mail not registered",
                timer: 2500,
                showConfirmButton: false
            });
        } else if (type == 'photo_view') {

            swal({	         
                html: '<script>$("#sweet-spacer").css("display","none"); </script><img src="http://3dp.theblueeye.com' + _a + '" style="max-width:1024px;width:100%;position:relative;top:0" />',	         
            });
        }

        else if (type == 'show_department') {


            swal({
                title: "부서 등록",
                text:  "부서를 저장하시겠습니까?",
              
                showCancelButton: true,
                confirmButtonText: "Save" ,
                cancelButtonText: "Cancel",
                closeOnConfirm: true,
                closeOnCancel: true,
                html: "<div class='form-group' ><label class='col-sm-3 control-label'>부서명</label><div class='col-md-9'><input type='text' name='department_name' id='department_name' class='form-control' /><input type='hidden'  name='company_idx' id='company_idx2'  value='" + _a + "'> </div></div>",


                }, function (isConfirm) {
                        if (isConfirm) {

                            //실행함수

                        department_go();

                    }
                }
                
            );
        }

        //else if (type == 'show_content') {
        //    swal({
        //        title: "세부내용",
        //        html:""
        //        });

        //}


    },

    initFormExtendedSliders: function() {

        // Sliders for demo purpose in refine cards section
        if ($('#slider-range').length != 0) {
            $("#slider-range").slider({
                range: true,
                min: 0,
                max: 500,
                values: [75, 300],
            });
        }
        if ($('#refine-price-range').length != 0) {
            $("#refine-price-range").slider({
                range: true,
                min: 0,
                max: 999,
                values: [100, 850],
                slide: function(event, ui) {
                    min_price = ui.values[0];
                    max_price = ui.values[1];
                    $(this).siblings('.price-left').html('&euro; ' + min_price);
                    $(this).siblings('.price-right').html('&euro; ' + max_price);
                }
            });
        }

        if ($('#slider-default').length != 0 || $('#slider-default2').length != 0) {
            $("#slider-default, #slider-default2").slider({
                value: 70,
                orientation: "horizontal",
                range: "min",
                animate: true
            });
        }
    },

    initFormExtendedDatetimepickers: function() {
        $('.datetimepicker').datetimepicker({
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: 'fa fa-chevron-left',
                next: 'fa fa-chevron-right',
                today: 'fa fa-screenshot',
                clear: 'fa fa-trash',
                close: 'fa fa-remove'
            }
        });

        $('.datepicker').datetimepicker({
            format: 'MM/DD/YYYY',
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: 'fa fa-chevron-left',
                next: 'fa fa-chevron-right',
                today: 'fa fa-screenshot',
                clear: 'fa fa-trash',
                close: 'fa fa-remove'
            }
        });

        $('.timepicker').datetimepicker({
//          format: 'H:mm',    // use this format if you want the 24hours timepicker
            format: 'h:mm A',    //use this format if you want the 12hours timpiecker with AM/PM toggle
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: 'fa fa-chevron-left',
                next: 'fa fa-chevron-right',
                today: 'fa fa-screenshot',
                clear: 'fa fa-trash',
                close: 'fa fa-remove'
            }
        });
    }
};