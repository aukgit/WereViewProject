﻿/// <reference path="byId.js" />
/// <reference path="D:\Working (SSD)\GitHub\WereViewProject\WereViewApp\Content/Scripts/toastr.js" />
/// <reference path="D:\Working (SSD)\GitHub\WereViewProject\WereViewApp\Content/Scripts/jquery-2.1.4.js" />
/// <reference path="D:\Working (SSD)\GitHub\WereViewProject\WereViewApp\Content/Scripts/jquery.blockUI.js" />
/// <reference path="D:\Working (SSD)\GitHub\WereViewProject\WereViewApp\Content/Scripts/jquery-2.1.4.intellisense.js" />
; $.app = $.app || {};
/**
* runs all the methods after initialize method.
*/
$.app.executeBefore = {
    /**
     * runs all the methods after initialize method.
     */
    toasterComponentSetup: function () {
        if (!$.isEmpty(toastr)) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": true,
                "progressBar": true,
                "positionClass": "toast-bottom-left",
                "preventDuplicates": true,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
        }
    },
    elasticTextAreas: function () {
        var $textAreas = $("textarea");
        if ($textAreas.length > 0) {
            $textAreas.find(".big-multiline").focus(function () {
                $(this).animate({ 'height': '300px', 'width': '630px', 'max-width': '630px' }, 400);
            }).blur(function () {
                $(this).animate({ 'height': 'auto', 'width': '294px', 'max-width': '294px' }, 400);
            });
            //making textarea's elastic
            $textAreas.elastic().trigger('update');
        }

    },
    toolTipShow: function () {
        var $tooltipItems = $('.tooltip-show');
        if ($tooltipItems.length > 0) {
            $tooltipItems.tooltip({ container: 'body' });
        }

    },
    seoHide: function () {
        var $seoHideItems = $(".seo-hide");
        if ($seoHideItems.length > 0) {
            $seoHideItems.hide();
        }
    },
    menuEnable: function () {
        $().jetmenu();
        var menuPage = $("#menu-item-edit-page");
        if (menuPage.length > 0) {
            var div = $("#hasDropdownDiv");
            div.hide();
            $("#HasDropDown").click(function () {
                if (this.checked) {
                    div.show('slow');
                } else {
                    div.hide('slow');
                }
            });
        }
    },
    bootstrapTableComponentEnable: function () {
        var $tables = $("table.bootstrap-table-do");
        if ($tables.length > 0) {
            $tables.bootstrapTable();
        }
    },
    datePickerComponentEnable: function () {
        if ($.isFunc($.datetimepicker)) {
            var $dateTimePicker = $(".datetimepicker-start");
            if ($dateTimePicker.length > 0) {
                $dateTimePicker.datetimepicker({
                    pickDate: true, //en/disables the date picker
                    pickTime: true, //en/disables the time picker
                    useMinutes: true, //en/disables the minutes picker
                    useSeconds: true, //en/disables the seconds picker
                    useCurrent: true, //when true, picker will set the value to the current date/time     
                    minuteStepping: 1, //set the minute stepping
                    defaultDate: "", //sets a default date, accepts js dates, strings and moment objects
                    disabledDates: [], //an array of dates that cannot be selected
                    enabledDates: [], //an array of dates that can be selected
                    sideBySide: true //show the date and time picker side by side
                });
            }
            var $datePicker = $(".datepicker-start");
            if ($datePicker.length > 0) {
                $datePicker.datetimepicker({
                    pickDate: true, //en/disables the date picker
                    pickTime: false, //en/disables the time picker
                    useMinutes: false, //en/disables the minutes picker
                    useSeconds: false, //en/disables the seconds picker
                    useCurrent: true, //when true, picker will set the value to the current date/time     
                    minuteStepping: 1, //set the minute stepping
                    defaultDate: "", //sets a default date, accepts js dates, strings and moment objects
                    disabledDates: [], //an array of dates that cannot be selected
                    enabledDates: [], //an array of dates that can be selected
                    sideBySide: true //show the date and time picker side by side
                });
            }
        }
    },
    transactionStatusEnable: function () {
        var $transaction = $("#transaction-container"),
            hideTimeOut = 0;
        if ($transaction.length !== 0) {
            if ($transaction.length > 0) {
                hideTimeOut = parseInt($($transaction[0]).attr("data-hide-duration"));
            }

            var hideStatus = function () {
                $transaction.each(function (index) {
                    var $this = $(this);
                    $this.attr("data-shown", "true")
                        .hide(500);
                });
            };
            var timer = setTimeout(hideStatus, hideTimeOut);

            var stopTimer = function () {
                clearTimeout(timer);
            }

            $transaction.click(function () {
                stopTimer();
                hideStatus();
            });
        }
    },

    loadWow: function () {
        var wow = new WOW({
            boxClass: 'wow', // animated element css class (default is wow)
            animateClass: 'animated', // animation css class (default is animated)
            offset: 100, // distance to the element when triggering the animation (default is 0)
            mobile: false // trigger animations on mobile devices (true is default)
        });
        wow.init();
    },

    ratingComponentEnable: function () {
        var $frontPageRatings = $.findCached(".rating-5-front");
        if ($frontPageRatings.length > 0) {
            $frontPageRatings.rating({
                showClear: false,
                showCaption: false
            });
        }

        var $detailPageRatingDisplayItems = $.findCached(".rating-5-page-details");
        if ($detailPageRatingDisplayItems.length > 0) {
            $detailPageRatingDisplayItems.rating({
                showClear: false,
                showCaption: true,
                starCaptions: {
                    0: "0",
                    0.5: "0.5",
                    1: "1",
                    1.5: "1.5",
                    2: "2",
                    2.5: "2.5",
                    3: "3",
                    3.5: "3.5",
                    4: "4",
                    4.5: "4.5",
                    5: "5"
                },
                starCaptionClasses: {
                    0: 'label label-danger',
                    0.5: 'label label-danger',
                    1: 'label label-danger',
                    1.5: 'label label-warning',
                    2: 'label label-warning',
                    2.5: 'label label-info',
                    3: 'label label-info',
                    3.5: 'label label-primary',
                    4: 'label label-primary',
                    4.5: 'label label-success',
                    5: 'label label-success'
                }
            });
        }
    },
};