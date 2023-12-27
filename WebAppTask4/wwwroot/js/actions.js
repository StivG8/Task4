$(document).ready(function () {
    let selectedRowData = [];

    $('#selectAll').click(function () {
        $('.userCheckbox').prop('checked', $(this).prop('checked'));
    });

    $('.userCheckbox').change(function () {
        if ($("input.userCheckbox:checked").length == $("input.userCheckbox").length) {
            $('#selectAll').prop('checked', $(this).prop('checked'));
        }
        else {
            $('#selectAll').prop('checked', false);
        }
    });

    $('#deleteButton').click(function () {

        $('.row-select input:checked').each(function () {
            let id;
            id = $(this).closest('tr').find('.Id').html();
            selectedRowData.push(id);
        });

        $.ajax({
            url: '/api/users/Delete',
            type: 'DELETE',
            data: JSON.stringify(selectedRowData),
            contentType: 'application/json',
            success: function (response) {
                location.reload();
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });

        selectedRowData = [];
    });

    $('#blockButton').click(function () {

        $('.row-select input:checked').each(function () {
            let id;
            id = $(this).closest('tr').find('.Id').html();
            selectedRowData.push(id);
        });

        $.ajax({
            url: '/api/users/Block',
            type: 'POST',
            data: JSON.stringify(selectedRowData),
            contentType: 'application/json',
            success: function (response) {
                location.reload();
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });

        selectedRowData = [];
    });

    $('#unblockButton').click(function () {

        $('.row-select input:checked').each(function () {
            let id;
            id = $(this).closest('tr').find('.Id').html();
            selectedRowData.push(id);
        });

        $.ajax({
            url: '/api/users/UnBlock',
            type: 'POST',
            data: JSON.stringify(selectedRowData),
            contentType: 'application/json',
            success: function (response) {
                location.reload();
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });

        selectedRowData = [];
    });
    
});