import { Component, OnInit } from '@angular/core';
import * as mapboxgl from 'mapbox-gl';
import { environment } from '../../../environments/environment';
import { ShopService } from '../../core/services/shop.service';

@Component({
  selector: 'app-shop',
  standalone: true,
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent implements OnInit {

  map!: mapboxgl.Map;
  style = 'mapbox://styles/mapbox/streets-v11';
  markers : mapboxgl.Marker[] = [];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    console.log('Iniciando un componente');
    console.log(`El token de mapbox viene de: ${environment.MAPBOX_TOKEN}`);
    this.map = new mapboxgl.Map({
      accessToken: environment.MAPBOX_TOKEN,
      style: this.style,
      container: "map",
      center: [-101.684168, 21.121628],
      zoom: 15
    });
    this.shopService.getAllStores().subscribe((storeResponse)=>{
      console.log(storeResponse);
      storeResponse.forEach((store)=>{
        const marker = new mapboxgl.Marker()
          .setLngLat([store.longitude, store.latitude])
          .addTo(this.map);
        this.markers.push(marker);
      });
    });
  }
}




// Pasos para obtener datos de una api 
//       1. Ver la respuesta de la api
//       2. Crear los modelos
//       3. Crear el servicio ( Crear metodos y peticiones a traves de httpclient )
//       4. Inyectar el servicio en el componente
//       5. Usar el servicio en el componente ( suscribirse a los observables )
  