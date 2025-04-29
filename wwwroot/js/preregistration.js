$(document).ready(function () {
    var countryDropdown = $('#CountryId');
    var cityDropdown = $('#CityId');
    var countryNameInput = $('#CountryName');
    var cityNameInput = $('#CityName');

    // Ülkeleri yükle
    $.get('/api/LokasyonApi/ulkeler', function (data) {
        $.each(data, function (i, item) {
            countryDropdown.append($('<option>', {
                value: item.id,
                text: item.tanım
            }));
        });
    });

    // Ülke seçimi değiştiğinde şehirleri yükle
    countryDropdown.change(function () {
        var selectedCountryId = $(this).val();
        cityDropdown.empty().append($('<option>', {
            value: '',
            text: 'Lütfen Seçin'
        })).prop('disabled', true);
        cityNameInput.prop('disabled', true).val('');

        if (selectedCountryId) {
            $.get('/api/LokasyonApi/sehirler/' + selectedCountryId, function (data) {
                if (data && data.length > 0) {
                    $.each(data, function (i, item) {
                        cityDropdown.append($('<option>', {
                            value: item.id,
                            text: item.tanım
                        }));
                    });
                    cityDropdown.prop('disabled', false);
                    cityNameInput.prop('disabled', true).val('');
                } else {
                    cityNameInput.prop('disabled', false);
                }
            });
        } else {
            cityNameInput.prop('disabled', false);
        }
    });
});