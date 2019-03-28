/*==============================================================*/
// Promedi Contact Form  JS
/*==============================================================*/
(function ($) {

	


    "use strict"; // Start of use strict
	$("#appform").validator().on("submit", function (event) {
        if (event.isDefaultPrevented()) {
            // handle the invalid form...
            formError();
            submitMSG(false, "Did you fill in the form properly?");
        } else {
            // everything looks good!
            event.preventDefault();
            submitForm();
        }
	});

    function submitForm(){
		var form = $("#appform");
		var formData = $(form).serialize();
        $.ajax({
            type: "POST",
			url: $(form).attr('action'),
			data: formData,
            success : function(text){
                if (text == "success"){
                    formSuccess();
                } else {
                    formError();
                    submitMSG(false,text);
                }
            }
        });
    }

    function formSuccess(){
		$("#appform")[0].reset();
        submitMSG(true, "Message Submitted!")
    }

    function formError(){
		$("#appform").removeClass().addClass('shake animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
            $(this).removeClass();
        });
	}
	function submitMSG(valid, msg) {
		if (valid) {
			var msgClasses = "h4 text-left tada animated text-success";
		} else {
			var msgClasses = "h4 text-left text-danger";
		}
		$("#msgSubmit").removeClass().addClass(msgClasses).text(msg);
	}


}(jQuery)); // End of use strict