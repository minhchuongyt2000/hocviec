// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function myfunction() {

    View.html('');
    LoadData("", null, 10, 0);
    $('#ViewOption').on("change", function () {
        selecteindex = $("#ViewOption").val();
        var input = $("#searchkey").val("");
        LoadData("", null, 10, selecteindex);
    });

    $('#searchkey').on("keyup", function () {
        var input = $("#searchkey").val();
        LoadData(input, null, 10, selecteindex)
    });
 
});

DataOption();

var selecteindex = 0;
var View = $('#view');

function pagination(CurrentPage, NumberPage, PageSize) {
    var str = "";
    if (NumberPage > 0) {
        str += '<nav aria-label="Page navigation example"> <ul class="pagination">';
        for (let i = 1; i <= NumberPage; i++) {
            if (CurrentPage === i) {
                str += '<li class="page-item active"><a class="page-link" href="javascript:void(0);">' + i + '</a></li>';
            } else {
                str += '<li class="page-item"><a class="page-link" onclick="nextPage(' + i + ',' + PageSize + ');" href="javascript:void(0);"> ' + i + '</a></li>';
            }
        }
        str += '</ul></nav>';
    }
    $("#pagination").html(str);
};

function nextPage(page, PageSize) {
    var searchkey = $("#searchkey").val();
    LoadData(searchkey, page, PageSize, selecteindex);
};

function LoadData(_searchkey, page, pageSize, selecteindex) {
    $.ajax({
        type: "GET",
        url: "/Staff/Load",
        data: { searchkey: _searchkey, page: page, pageSize: pageSize, selecteIndex: selecteindex },
        success: function (data) {
            if (data.isValid) {
                View.html(data.html);
                pagination(data.currentPage, data.numberPage, data.pageSize);
            } else {
                View.html('<tr><td colspan="7" class="text-danger fs-2 text-center">No Data!</td></tr>');
                $("#pagination").html("");
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
};

showpopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#form-modal .modal-body').html(data);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    });
};

JqueryPost = form => {
    try {
        var icon = "";
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            beforeSend: function () {
                $('#Loadding').removeClass('hidden')
            },
            success: function (data) {
                if (data.isValid) {
                    icon = "success";
                    $('#form-modal .modal-body').html("");
                    $('#form-modal .modal-title').html("");
                    LoadData("", null, 10, selecteindex);
                    $("#form-modal").modal('hide');
                    notify(data.msg,icon);
                } else {
                    icon = "error";
                    notify(data.msg,icon);
                    $('#form-modal .modal-body').html(data.html);
                }

            },
            error: function (error) {
                console.log(error);

            },
            complete: function (data) {
                $('#Loadding').addClass('hidden')
            },

        });
    } catch (e) {
        console.log(e);
    }
    return false;
};

function DataOption() {
    var xml = "";
    $.ajax({
        type: "POST",
        url: "/Staff/GetDataOption",
        dataType: "json",
        success: function (data) {
            if (data.isValid) {
                xml = '<option value="0" selected>--ALL--</option>';
                $.each(data.list, function (key, value) {
                    xml += "<option value=" + value.id + ">" + value.name + "</option>";
                });
                $("#ViewOption").html(xml);
            }
        
        },
        error: function (error) {

        },
    });
};

function notify(title, icon) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: icon,
        title: title
    });
};
