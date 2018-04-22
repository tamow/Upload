const puppeteer = require('puppeteer');

puppeteer.launch({
	headless: false
	    }).then(async browser => {
		    const page = await browser.newPage();
		    await page.setViewport({ width: 1200, height: 800 }); // view portの指定
			await page.goto('https://www.smbc-card.com/mem/index.jsp', {waitUntil: 'networkidle2'});
			await page.waitFor(30000);

			var url = 'https://www.smbc-card.com/memx/web_meisai/top/index.html#info2';
		    await page.goto(url, {waitUntil: 'networkidle2'});

		    for (var year = 2017; year <= 2018; year++) {
		    	for (var month = 2; month <= 3; month++) {
					await page.select('select#vp-view-VC0502-003_RS0001_p01', year + (('0' + month).slice(-2)));
					await page.click('#U051112-btn01');
					await page.waitFor(5000);
					await page.click('#vp-view-VC0502-003_RS0001_U051111_3');
					await page.waitFor(5000);		    		
		    	}
		    }
		    browser.close();
		});