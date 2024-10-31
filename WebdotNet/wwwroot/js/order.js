var dataTable;

$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            "ajax": {url :'/admin/order/getall'
        },
            "columns": [
                { data: 'id', "width" : "15%" },
                { data: 'name', "width": "10%" },
                { data: 'address', "width": "15%" },
                { data: 'phoneNumber', "width": "10%" },
                { data: 'orderStatus', "width": "15%" },
                {data: 'orderTotal', "width":"15%"},
                {
                    data: 'orderTotal',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                        <a href="/Admin/Order/Edit/?id=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i>Edit
                        </a>
                    </div>`;
                    },
                    "width": "20%"
                }
        ]
        });
}

