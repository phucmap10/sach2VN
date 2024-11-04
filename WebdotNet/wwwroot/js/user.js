var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "30%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "address", "width": "30%" },
            { "data": "userName", "width": "10%" }
        ]
    });
}
