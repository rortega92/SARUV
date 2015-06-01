@Code
    ViewData("Title") = "Calendar"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
@Styles.Render("~/Content/css")
@Styles.Render("~/Content/fullcalendarcss")
@Scripts.Render("~/bundles/fullcalendarjs")
@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/fullcalendarjs")

<script type="text/javascript">


    $(document).ready(function () {
        $('#calendar').fullCalendar({
            theme: false,

            //defaultView: 'agendaDay',
            editable: true,
            events: "/home/getevents/"
        });
        $('#calendar').fullCalendar('render');
    });


</script>

<!DOCTYPE html>

<h2>Calendar</h2>
<div id="calendar"></div>


    
  