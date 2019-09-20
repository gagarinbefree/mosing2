import { connect } from 'react-redux';
import * as Actions from '../actions/WorldMap';
import WorldMap, { IWorldMapProps, IWordMapPayload, IPlace } from '../components/WorldMap';
import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

const mapStateToProps = (state: any): IWordMapPayload => {
	return state.WorldMapReducer.payload;
}

const mapDispatchToProps = (dispatch: ThunkDispatch<IWordMapPayload, {}, AnyAction>): IWorldMapProps => {
    return {  
		getTravelAsync: async (): Promise<void> => dispatch(Actions.getTravelAsync()),
        setMarker: (place: IPlace): Actions.ISetMarkerAction => dispatch(Actions.setMarker(place))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(WorldMap);