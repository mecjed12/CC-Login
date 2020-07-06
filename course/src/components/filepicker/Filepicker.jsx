import React from 'react';
import '../filepicker/Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput'


export default class Filepicker extends React.Component {

    constructor(props) {
        super(props);
          this.state = {
            selectedFile: null
          }
      }
    

    onChangeHandler=event=>{
        this.setState({
            selectedFile: event.target.files[0],
            loaded: 0,
          })
        console.log(event.target.files[0])
    }

    onClickHandler = (config) => {
        const data = new FormData() 
        data.append('file', this.state.selectedFile)
        data.append('config', config)

       // if (config  kurstitel od kursinhalt oder erstellt am = leer => alert)

        axios.post("http://localhost:3000/upload", data, { 
        })
        .then(res => {   // then print response status
            console.log(res.statusnumber)
         })
    }

    render() {
        return (
            <div className="file-container">
                <div className="body-filepicker">
                    <label>Kurs-Datei auswählen!</label>
                    <input type="file" name="file" onChange={this.onChangeHandler}/> 
                </div>
                <Fileinput upload={this.onClickHandler}/>
            </div>
        )
    }
}