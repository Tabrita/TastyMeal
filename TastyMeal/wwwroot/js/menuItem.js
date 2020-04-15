var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/menuitem",
            "datatype": "json",
            "type": "GET"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "20%" },
            { "data": "foodType.name", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a class="btn btn-primary" href="/Admin/MenuItem/upsert?id=${data}" style="cursor:pointer;">
                                <i class="far fa-edit"></i>
                            </a>
                            &nbsp;
                            <a onclick= "Delete('/api/menuitem/'+${data})" class="btn btn-danger text-white" style="cursor:pointer;">
                                <i class="far fa-trash-alt"></i>
                            </a>
                        </div>                       
                    `;
                },
                "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {

                        swal(data.data.name + " has been deleted!", {
                            icon: "success",
                        });
                        //toastr.success(data.messsage);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.messsage);
                    }
                }
            });
        }
    });
}