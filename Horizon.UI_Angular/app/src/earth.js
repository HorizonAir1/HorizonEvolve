
			var container, stats;
			var camera, scene, renderer;
			var group;
			var mouseX = 0, mouseY = 0;

			var windowHalfX = window.innerWidth / 2;
			var windowHalfY = window.innerHeight / 2;

			init();
			animate();

			function init() {

				container = document.getElementById( 'container' );

				camera = new THREE.PerspectiveCamera( 60, window.innerWidth / window.innerHeight, 1, 2000 );
				camera.position.z = 200;





				scene = new THREE.Scene();

				group = new THREE.Group();
				scene.add( group );

				// earth

				var loader = new THREE.TextureLoader();
				loader.load( '../three.js/examples/textures/planets/earth_lights_2048.png', function ( texture ) {

					var geometry = new THREE.SphereGeometry( 200, 20, 20 );

					var material = new THREE.MeshBasicMaterial( { map: texture, overdraw: 0.5 } );
					var mesh = new THREE.Mesh( geometry, material );
					group.add( mesh );

				} );

				// shadow

//

				renderer = new THREE.CanvasRenderer({alpha:true});
                renderer.setClearColor(0x000000,0);
				renderer.setPixelRatio( window.devicePixelRatio );
				renderer.setSize( window.innerWidth, window.innerHeight );
				container.appendChild( renderer.domElement );

				// stats = new Stats();
				// container.appendChild( stats.dom );

				document.addEventListener( 'mousemove', onDocumentMouseMove, false );

				//

				window.addEventListener( 'resize', onWindowResize, false );

			}

			function onWindowResize() {

				windowHalfX = window.innerWidth / 2;
				windowHalfY = window.innerHeight / 2;

				camera.aspect = window.innerWidth / window.innerHeight;
				camera.updateProjectionMatrix();

				renderer.setSize( window.innerWidth, window.innerHeight );

			}

			function onDocumentMouseMove( event ) {

				mouseX = ( event.clientX - windowHalfX );
				mouseY = ( event.clientY - windowHalfY );

			}

			//

			function animate() {

				requestAnimationFrame( animate );

				render();


			}

			function render() {

				camera.position.x = 200;
				camera.position.y = 400;


                var x = new THREE.Vector3(0,0,150);
				camera.lookAt(x);


				group.rotation.y -= 0.002;

				renderer.render( scene, camera );

			}
