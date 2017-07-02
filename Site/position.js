$(document).ready(function() {
	relocation();
	
	$(window).resize(function() {
		relocation();
	});
});

function relocation()
{
	var widthWindow = $(window).width();
	var heightWindow = $(window).height();
	
	var paddingHorizontal = parseInt($('.content').css('padding-left').replace('px', ''))
		+ parseInt($('.content').css('padding-right').replace('px', ''));
	var paddingVertical = parseInt($('.content').css('padding-top').replace('px', ''))
		+ parseInt($('.content').css('padding-bottom').replace('px', ''));

	var widthBox = $('.content').width() + paddingHorizontal;
	var heightBox = $('.content').height() + paddingVertical;
	
	var topMargin = parseInt((heightWindow - heightBox) / 2);
	var leftMargin = parseInt((widthWindow - widthBox) / 2);
	
	if (topMargin < 0) topMargin = 0;
	if (leftMargin < 0) leftMargin = 0;
	
	var margin = topMargin + 'px ' + leftMargin + 'px';
	
	$('body').css('margin', margin);
	$('.bigBall').show();
}