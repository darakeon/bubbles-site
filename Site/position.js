$(document).ready(function() {
	relocation();
	
	$(window).resize(function() {
		//relocation();
	});
});

function relocation()
{
	var widthWindow = $(window).width();
	var heightWindow = $(window).height();
	
	var widthBox = $('.bigBall').width();
	var heightBox = $('.bigBall').height();
	
	var topMargin = parseInt((heightWindow - heightBox) / 2);
	var leftMargin = parseInt((widthWindow - widthBox) / 2);
	
	var margin = topMargin + 'px ' + leftMargin + 'px';
	
	$('body').css('margin', margin);
	$('.bigBall').show();
}