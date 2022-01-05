(function($) {
  'use strict';
  $(function() {
    var todoListItem = $('.todo-list');
    var todoListInput = $('.todo-list-input');
    $('.todo-list-add-btn').on("click", function(event) {
      event.preventDefault();

      var item = $(this).prevAll('.todo-list-input').val();

        $.ajax({
            url: '/BoardUsers/AddTask?taskContent='+item,
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (result == "error") {
                    alert("can't add task")
                }
                else {
                    if (item) {
                        var appendedText = "<li><div class='form-check'><label class='form-check-label'><input class='checkbox' type='checkbox' name='" + result + "' />" + item + "<i class='input-helper'></i></label></div><i name='" + result + "' class='remove mdi mdi-close-box'></i></li>"
                        todoListItem.append(appendedText);
                        todoListInput.val("");
                    }
                }
            }
        });
      

    });

      todoListItem.on('change', '.checkbox', function () {
          var test = this;
          var isChecked = true;
          var taskId = $(this).attr('name');
          if ($(this).is(":checked")) {
              isChecked = true;
          } else {
              isChecked = false;
          }
          //call updateTaskStatus
          $.ajax({
              url: '/BoardUsers/UpdateTaskStatus?taskId=' + taskId + '&taskStatus=' + isChecked,
              dataType: 'json',
              context: this,
              contentType: "application/json; charset=utf-8",
              success: function (result) {
                  if (result == "error") {
                      alert("can't update task")
                  }
                  else {
                      if ($(this).attr('checked')) {
                          $(this).removeAttr('checked');
                      } else {
                          $(this).attr('checked', 'checked');
                      }
                      $(this).closest("li").toggleClass('completed');
                  }
              }
          });
    });

      todoListItem.on('click', '.remove', function () {
          var taskId = $(this).attr('name');
          $.ajax({
              url: '/BoardUsers/DeleteTask?taskId=' + taskId ,
              dataType: 'json',
              context: this,
              contentType: "application/json; charset=utf-8",
              success: function (result) {
                  if (result == "error") {
                  }
                  else {
                      $(this).parent().remove();
                  }
              }
          });
    });

  });
})(jQuery);