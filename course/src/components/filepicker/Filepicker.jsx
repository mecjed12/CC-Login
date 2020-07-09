import React from 'react';
import '../filepicker/Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput'


export default class Filepicker extends React.Component {

    constructor(props) {
        super(props);
        this.getOptions()
        this.state = {
            selectedFile: null
        }
    }

    options = [];
    
    getOptions() {
        
        var xhttp = new XMLHttpRequest();

        axios.get("http://192.168.0.94:8017/BewerbungenApi").then(res => {
            this.options = res.data
            this.options.forEach(option => {
                console.log(option)
            })
    
        }).catch(err => console.log(err))

       
    }

    onChangeHandler = event => {
        this.setState({
            selectedFile: event.target.files[0],
            loaded: 0,
        })
    }

    onClickHandler = (config) => {
        const data = new FormData()
        data.append('file', this.state.selectedFile)
        data.append('config', JSON.stringify(config))

        axios.post("http://localhost:3000/upload", data)
            .then(res => {   // then print response status
                console.log(res.statusText)
            })

        if (!this.state.selectedFile) {
            alert("Bitte Datei auswählen!")
            return;
        }
    }

    render() {
        return (
            <div>
                <div className="container">
                    <div className="dropdown">
                        <button className="dropbtn">Bitte auswählen...<i className="fa fa-caret-down"></i></button>
                        <div className="dropdown-content">
                            <a href="#">Personen</a>
                            <a href="#">Kurse</a>
                        </div>
                    </div>
                    {/* <select>
                        <option>Personen</option>
                        <option>Kurse</option>
                    </select> */}
                   
                    <div className="body-filepicker">
                        <label></label>
                        <input type="file" name="file" onChange={this.onChangeHandler} />
                    </div>
                </div>
                <Fileinput upload={this.onClickHandler} />
            </div>
        )
    }
}