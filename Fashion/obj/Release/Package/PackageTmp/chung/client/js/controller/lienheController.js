var lh = {
    init: function () {
        lh.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var sdt = $('#txtSdt').val();
            var diachi = $('#txtDiachi').val();
            var email = $('#txtEmail').val();
            var tintuc = $('#txtTintuc').val();

            $.ajax({
                url: '/Lienhe/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    sdt: sdt,
                    diachi: diachi,
                    email: email,
                    tintuc: tintuc
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi thành công');
                        lh.resetForm();
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtSdt').val('');
        $('#txtDiachi').val('');
        $('#txtEmail').val('');
        $('#txtTintuc').val('');
    }
}
lh.init();