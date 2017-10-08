$(document).ready(function () {
  // Wire up the Add button to send the new item to the server
  $('#add-item-button').on('click', addItem);
  // Setup Datepicker
  $('#add-item-dueAt').datepicker();

  // Wire up all of the checkboxes to run markCompleted()
  $('.done-checkbox').on('click', function (e) {
    markCompleted(e.target);
  });

});

function addItem() {
  $('#add-item-error').hide();
  var newTitle = $('#add-item-title').val();
  var newDueAt = $('#add-item-dueAt').val();

  $.post('/Todo/AddItem', { title: newTitle, dueAt: newDueAt }, function () {
    window.location = '/Todo';
  })
    .fail(function (data) {
      if (data && data.responseJSON) {
        var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
        $('#add-item-error').text(firstError);
        $('#add-item-error').show();
      }
    });
}

function markCompleted(checkbox) {
  checkbox.disabled = true;

  $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
    var row = checkbox.parentElement.parentElement;
    $(row).addClass('done');
  });
}
