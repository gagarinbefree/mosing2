import { Dispatch, Action } from 'redux';
import { IPlace, ITravel, IRoute } from '../components/WorldMap';
import { xml2js, Element, ElementCompact } from 'xml-js'

interface IGetTravelAction extends Action {
	travel: ITravel | null,
	error: string
	
}

export interface ISetMarkerAction extends Action {
	marker: IPlace
}

export const getTravel = (travel: ITravel | null, error: string): IGetTravelAction => ({
    type: 'WORLD_MAP_GET_TRAVEL',
    travel,
    error
})

export const setMarker = (marker: IPlace): ISetMarkerAction => ({
    type: 'WORLD_MAP_SET_MARKER',
    marker
})

export const getTravelAsync = () => {
    return async (dispatch: Dispatch<IGetTravelAction>): Promise<void> => {
        try {
            const req = await fetch('/Travel', { method: 'GET' });
            const res: ITravel = await req.json();

            dispatch(getTravel(res, ''));
        }
        catch (ex) {
			dispatch(getTravel(null, ex));
			
			console.log(ex);
        }
	}	
}

const parseXML = (xml: Element | ElementCompact): ITravel => {
	let res: ITravel = {
		routes: [] as IRoute[]
	};
	
	xml.elements[0].elements.forEach((r: any) => {
		let route: IRoute = {
			label: r.attributes.part,
			options: [] as IPlace[]
		}
		res.routes.push(route);
		r.elements.forEach((p: any) => {
			let place: IPlace = {
				label: p.elements[0].elements[0].text,
				value: `${p.elements[1].elements[0].text};${p.elements[2].elements[0].text}`
			}		
			route.options.push(place);
		});
	});
	
	return res;
}

