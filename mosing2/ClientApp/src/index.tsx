import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './components/App';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './reducers/Index';
import * as serviceWorker from './serviceWorker';
import L from 'leaflet';
import icon from 'leaflet/dist/images/marker-icon.png';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';
import './index.css';

const configureStore = (initialState: any) => createStore(rootReducer, initialState, applyMiddleware(thunk));

export const store = configureStore(undefined);

ReactDOM.render(
    <Provider store={store}>
        <App />
  </Provider>,
  document.getElementById('root')
);

serviceWorker.unregister();

L.Marker.prototype.options.icon = L.icon({
	iconUrl: icon,
	shadowUrl: iconShadow
});