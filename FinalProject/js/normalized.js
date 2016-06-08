		function normalized(img, w, h){
			var c;
			var context;

			if(img.height < h || img.width < w){
				c = document.createElement('canvas');
				c.width = w;
				c.height = h;
				context = c.getContext('2d');
				context.putImageData(img, 0, 0);
				return context.getImageData(0, 0, w, h);
			}

			return img;
		}