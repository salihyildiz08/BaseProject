//[Dashboard Javascript]

//Project:	SoftMaterial admin - Responsive Admin Template
//Primary use:   Used only for the main dashboard (index.html)

$(function () {

  'use strict';

	
	

	
  //Daily-inquery
	
	var donut = new Morris.Donut({
      element: 'daily-inquery',
      resize: true,
      colors: ["#9C27B0", "#FF9149", "#E91E63"],
      data: [
        {label: "On Site", value: 150},
        {label: "By eMail", value: 80},
        {label: "By Phone", value: 110}
      ],
      hideHover: 'auto'
    });

  // Property Stats
    var area = new Morris.Area({
      element: 'property-stats',
      resize: true,
      data: [
        { y: '2017-01', a: 135,  b: 235 },
		{ y: '2017-02', a: 235,  b: 335 },
		{ y: '2017-03', a: 135,  b: 235 },
		{ y: '2017-04', a: 335,  b: 435 },
		{ y: '2017-05', a: 535,  b: 435 },
		{ y: '2017-06', a: 335,  b: 235 },
		{ y: '2017-07', a: 235,  b: 135 }
      ],
		xkey: 'y',
		ykeys: ['a', 'b'],
		labels: ['Commercial Projects', 'Residential Projects'],
		fillOpacity: 0.2,
		lineWidth:2,
		lineColors: ['#1E9FF2', '#E91E63'],
		hideHover: 'auto',
		color: '#666666'
    });
	
	//Booking Status
    var bar = new Morris.Bar({
      element: 'bar-chart',
      resize: true,
      data: [
        {y: '18/4/2018', a: 80, b: 95},
        {y: '19/4/2018', a: 85, b: 95},
        {y: '20/4/2018', a: 83, b: 86},
        {y: '21/4/2018', a: 77, b: 92},
        {y: '22/4/2018', a: 65, b: 100},
        {y: '23/4/2018', a: 100, b: 60},
		{y: '24/4/2018', a: 89, b: 90}
      ],
		barColors: ['#1E9FF2', '#FF9149'],
		barSizeRatio: 0.8,
		barGap:8,
		xkey: 'y',
		ykeys: ['a', 'b'],
		labels: ['Inquery', 'Conform'],
		hideHover: 'auto'
    });
	
	
}); // End of use strict

