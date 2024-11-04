var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "phoneNumber", "width": "20%" },
            { "data": "address", "width": "20%" },
            { "data": "userName", "width": "20%" }
        ]
    });
}
