(function($) {

    var form = $("#signup-form");
    form.validate({
        errorPlacement: function errorPlacement(error, element) {
            element.before(error);
        },
        rules: {
            email: {
                email: true
            }
        },
        onfocusout: function(element) {
            $(element).valid();
        },
    });
    form.children("div").steps({
        headerTag: "h3",
        bodyTag: "fieldset",
        transitionEffect: "fade",
        stepsOrientation: "vertical",
        titleTemplate: '<div class="title"><span class="step-number">#index#</span><span class="step-text">#title#</span></div>',
        labels: {
            previous: 'Previous',
            next: 'Next',
            finish: 'Finish',
            current: ''
        },
        onStepChanging: function (event, currentIndex, newIndex) {
            //var Qindex = currentIndex + 1;
            //var classname = "question " + Qindex;
            //var valid = true;
            //var isMultiSelect = false;
            //var questionDivs = document.getElementsByClassName(classname);
            //for (var div of questionDivs) {
            //    var inputs = div.getElementsByTagName('input');
            //    var flag = false;
            //    for (var input of inputs) {
            //        if (input.type == "checkbox" || input.type == "radio") {
            //            isMultiSelect = true;
            //            if (input.checked) {
            //                flag = true;
            //                break;
            //            }
            //        }
            //    }
            //    if (!flag && isMultiSelect) {
            //        div.style.border = "solid #d93025";
            //        div.style.borderRadius = "10px";
            //        div.getElementsByClassName("error-message")[0].innerHTML = ' This is a required question';
            //        div.getElementsByClassName("error-message")[0].style.display = 'block';
            //        flag = false;
            //        valid = false;
            //        isMultiSelect = false;
            //    }
            //    else {
            //        div.style.border = 'none';
            //        div.getElementsByClassName("error-message")[0].style.display = 'none';
            //    }
            //}
            var valid = validate(currentIndex);
            form.validate().settings.ignore = ":disabled";
            if (valid || (currentIndex > newIndex)) {
                return form.valid();
            }
            else {
                return !form.valid();
            }
            if (currentIndex === 0) {
                form.parent().parent().parent().append('<div class="footer footer-' + currentIndex + '"></div>');
            }
            if (currentIndex === 1) {
                form.parent().parent().parent().find('.footer').removeClass('footer-0').addClass('footer-' + currentIndex + '');
            }
            if (currentIndex === 2) {
                form.parent().parent().parent().find('.footer').removeClass('footer-1').addClass('footer-' + currentIndex + '');
            }
            if (currentIndex === 3) {
                form.parent().parent().parent().find('.footer').removeClass('footer-2').addClass('footer-' + currentIndex + '');
            }
            // if(currentIndex === 4) {
            //     form.parent().parent().parent().append('<div class="footer" style="height:752px;"></div>');
            // }
        },
        onFinishing: function(event, currentIndex) {
            //form.validate().settings.ignore = ":disabled";
            //return form.valid();
            var valid = validate(currentIndex);
            form.validate().settings.ignore = ":disabled";
            if (valid) {
                return form.valid();
            }
            else {
                return !form.valid();
            }
        },
        onFinished: function (event, currentIndex) {
            return form.submit();
        },
        onStepChanged: function (event, currentIndex, priorIndex) {
            
            return true;
        }
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "",
        remote: "",
        email: "",
        url: "",
        date: "",
        dateISO: "",
        number: "",
        digits: "",
        creditcard: "",
        equalTo: ""
    });

    $.dobPicker({
        daySelector: '#birth_date',
        monthSelector: '#birth_month',
        yearSelector: '#birth_year',
        dayDefault: '',
        monthDefault: '',
        yearDefault: '',
        minimumAge: 0,
        maximumAge: 120
    });
    var marginSlider = document.getElementById('slider-margin');
    if (marginSlider != undefined) {
        noUiSlider.create(marginSlider, {
              start: [1100],
              step: 100,
              connect: [true, false],
              tooltips: [true],
              range: {
                  'min': 0,
                  'max': 10
              },
              pips: {
                    mode: 'values',
                    values: [0, 10],
                    density: 2
                    },
                format: wNumb({
                    decimals: 0,
                    thousand: '',
                    prefix: '',
                })
        });
        var marginMin = document.getElementById('value-lower'),
	    marginMax = document.getElementById('value-upper');

        marginSlider.noUiSlider.on('update', function ( values, handle ) {
            if ( handle ) {
                marginMax.innerHTML = values[handle];
            } else {
                marginMin.innerHTML = values[handle];
            }
        });
    }
})(jQuery);
function validate(currentIndex) {
    var Qindex = currentIndex + 1;
    var classname = "question " + Qindex;
    var valid = true;
    var isMultiSelect = false;
    var questionDivs = document.getElementsByClassName(classname);
    for (var div of questionDivs) {
        var inputs = div.getElementsByTagName('input');
        var flag = false;
        for (var input of inputs) {
            if (input.type == "checkbox" || input.type == "radio") {
                isMultiSelect = true;
                if (input.checked) {
                    flag = true;
                    break;
                }
            }
        }
        var additionalInfoCheckBox = div.getElementsByClassName("other-info-checkbox")[0];
        if (isMultiSelect) {
            if (additionalInfoCheckBox.checked) {
                if (div.getElementsByClassName("other-info-input")[0].value == "") {
                    flag = false;
                }
            }
        }
        if (!flag && isMultiSelect) {
            div.style.border = "solid #d93025";
            div.style.borderRadius = "10px";
            div.getElementsByClassName("error-message")[0].innerHTML = ' This is a required question';
            div.getElementsByClassName("error-message")[0].style.display = 'block';
            flag = false;
            valid = false;
            isMultiSelect = false;
        }
        else {
            div.style.border = 'none';
            div.getElementsByClassName("error-message")[0].style.display = 'none';
        }


    }
    return valid;
}