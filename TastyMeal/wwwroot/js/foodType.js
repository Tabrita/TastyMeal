var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/foodtype",
            "datatype": "json",
            "type": "GET"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a class="btn btn-primary" href="/Admin/FoodType/upsert?id=${data}" style="cursor:pointer;width:100px">
                                <i class="far fa-edit"></i>Edit
                            </a>
                            &nbsp;
                            <a onclick= "Delete('/api/foodtype/'+${data})" class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="far fa-trash-alt"></i> Delete
                            </a>
                        </div>                       
                    `;
                },
                "width": "50%"
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
                url: url,
                type: "DELETE",
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