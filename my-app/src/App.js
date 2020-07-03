import React from 'react';
import logo from './logo.svg';
import './App.css';
import Head from './components/header/Head';
import Filepicker from './components/Filepickeer/Filepicker';



class App extends React.Component {
 
  render() {
    return (

      <div className="container">
        <Head/>
        <Filepicker/>
      </div>
        
      
    );
  }
}

export default App;