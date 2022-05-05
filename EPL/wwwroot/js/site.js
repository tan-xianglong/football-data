// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var name = button.data('name');
    var id = button.data('id');
    var controller = button.data('controller');
    var primarykey = button.data('primarykey');
    var modal = $(this);
    modal.find('.modal-body p').text('Are you sure you want to delete ' + name + '?');
    modal.find('.modal-footer form').attr('action', `/${controller}/Delete?${primarykey}=${id}`);
});