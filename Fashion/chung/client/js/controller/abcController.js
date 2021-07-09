(function () {
    var data = [];
    function init() { 
        $.getJSON("/chung/client/data/http.json", function (res) {
            data = res.data;
            renderProvince(data);
        });
    };

    function renderProvince(data) {
        $('#cboProvince').append('<option value="0">Chon tinh thanh</option>');
        $.each(data, function (i, item) {
            $('#cboProvince').append($('<option>', { value: item.level1_id, text: item.name }));
        });
        $('#cboProvince').val(0).trigger('change');
    }

    $('#cboProvince').on('change', function () {
        var provinceId = this.value;
        $('#cboDistrict').empty();

        var selectedProvince = data.find(item => item.level1_id === provinceId);

        if (selectedProvince) {
            $.each(selectedProvince.level2s, function (i, item) {
                $('#cboDistrict').append($('<option>', { value: item.level2_id, text: item.name }));
            });
        }
    });
    init()
})();
