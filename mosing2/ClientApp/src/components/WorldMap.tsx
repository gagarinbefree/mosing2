import React from 'react'
import { Map, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import Select from 'react-select';
import { ValueType } from 'react-select/src/types';
import 'leaflet/dist/leaflet.css';

export interface IWorldMap {
	lat: number,
	long: number,
	zoom: number
}

export interface IPlace {
	label: string,
	value: string,	
}

export interface ITravel {
	routes: IRoute[]
}

export interface IRoute {
	label: string,
	options: IPlace[]
}

export interface IWorldMapState {
    type: string;
    payload: IWordMapPayload;
}

export interface IWordMapPayload {    
	map: IWorldMap,
	travel: ITravel | null;
	marker: IPlace | null;
	error: string;
}

export interface IWorldMapProps {
	getTravelAsync(): Promise<void>;
	setMarker(place: IPlace | null): void;
}

class WorldMap extends React.Component<IWorldMapProps & IWordMapPayload> {
	constructor(props: IWorldMapProps & IWordMapPayload) {
		super(props);        
	}

	async componentDidMount() {
		await this.props.getTravelAsync();
	}

	handleChange = (e: ValueType<IPlace>) => {		
		this.props.setMarker(e as IPlace)
	}

	render() {
		let position: [number, number] = [this.props.map.lat, this.props.map.long];
		if (this.props.marker)
		{
			let str: string[] = this.props.marker.value.split(';');
			position = [parseFloat(str[0]), parseFloat(str[1])];
		}

		return <React.Fragment>
			<Map center={position} zoom={this.props.map.zoom} style={{ width: '100%', height: '100vh' }}>
				<TileLayer attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
					url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
				/>				
				{this.props.marker && <Marker position={position}>
					<Popup><p>{this.props.marker.label}</p></Popup>
				</Marker>}
			</Map>
			<div className="select">
				<Select options={this.props.travel ? this.props.travel.routes : undefined} 
					onChange={this.handleChange}
					isClearable={true
				}/>
			</div>
		</React.Fragment>
	}
}

export default WorldMap;