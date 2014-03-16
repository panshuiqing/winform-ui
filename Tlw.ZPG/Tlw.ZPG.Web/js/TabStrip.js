//选项卡js
$(document).ready(function () {
    $('#TabStrip table').hover(function () {
        if (!$(this).hasClass('SelectedTab')) {
            $(this).removeClass('DefaultTab').addClass('DefaultTabHover');
            $('td:first img', this).attr('src', 'images/tabStrip/hover_tab_left_icon.gif');
            $('td:last img', this).attr('src', 'images/tabStrip/hover_tab_right_icon.gif');
        }
    }, function () {
        if (!$(this).hasClass('SelectedTab')) {
            $(this).removeClass('DefaultTabHover').addClass('DefaultTab');
            $('td:first img', this).attr('src', 'images/tabStrip/tab_left_icon.gif');
            $('td:last img', this).attr('src', 'images/tabStrip/tab_right_icon.gif');
        }
    }).click(function () {
        if (!$(this).hasClass('SelectedTab')) {
            var selectedTab = $('table.SelectedTab');
            $('td:first img', selectedTab).attr('src', 'images/tabStrip/tab_left_icon.gif');
            $('td:last img', selectedTab).attr('src', 'images/tabStrip/tab_right_icon.gif');
            $('table.SelectedTab').removeClass('SelectedTab').addClass('DefaultTab');
            $(this).removeClass('DefaultTabHover').addClass('SelectedTab');
            $('td:first img', this).attr('src', 'images/tabStrip/selected_tab_left_icon.gif');
            $('td:last img', this).attr('src', 'images/tabStrip/selected_tab_right_icon.gif');
            $('.MultiPage table').hide();
            var id = $(this).attr('pageView');
            $('.MultiPage #' + id).show();
            $('.MultiPage #' + id + ' table').show();
        }
    });
});