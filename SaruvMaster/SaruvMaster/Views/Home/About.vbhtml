@Code
    ViewData("Title") = "Calendario"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
@Styles.Render("~/Content/css")
@Styles.Render("~/Content/fullcalendarcss")
@Scripts.Render("~/bundles/modernizr")
@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/fullcalendarjs")
<script type='text/javascript' src='Scripts/gcal.js'></script>
<script type='text/javascript' src='fullcalendar/gcal.js'></script>
<script type="text/javascript">


    $(document).ready(function () {
        $('#calendar').fullCalendar({
            theme: false,
            header: {
                left: '',
                center: 'prev title next',
                right: 'month agendaWeek agendaDay'
            },
            googleCalendarApiKey: 'AIzaSyAiY8MQ5NwF9F_wCEFvcsgbg2zLgT5THNc',
            //defaultView: 'agendaDay',
            editable: true,
            events: {
                googleCalendarId: 'tbvmq74rfsgojcaqbd9nacv6m4@group.calendar.google.com'
            }
        });
    });


</script>

<section class="panel">
    <header class="panel-heading">
        Calendario
    </header>
    <div class="panel-body">
        <div id="calendar"></div>

    </div>
</section>

