
        $('.panel-group').on('show.bs.collapse shown.bs.collapse hide.bs.collapse hidden.bs.collapse', function (e) {
            e.stopPropagation();
        });