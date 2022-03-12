import { View, Text, Pressable, StyleSheet } from 'react-native'
import React, { useEffect } from 'react'
import Icon from 'react-native-vector-icons/FontAwesome';
import { actionCreator } from '../store/action-creators/photo-action-creators';
import { connect } from 'react-redux';

import PhotosList from '../components/photos/PhotosList';

function Photo(props) {

  useEffect(() => {
    props.getPhotos();
  }, [])
  
  return (
    <View style={styles.content}>
      <View style={styles.gallery_container}>
        <Text style={styles.gallery}>Gallery</Text>
        <PhotosList dataList={props.photo} />
      </View>
      <View style={styles.button_container}>
        <Pressable style={styles.button} onPress={onClick} >
          <Icon name="camera" color="#ffff" size={25}/>
          <Text style={styles.text_button}>Take a Picture</Text>
        </Pressable>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  content: {
    height: '100%',
    paddingVertical: '10%',
    marginTop: 50,
  },
  gallery_container: {
    height: '83%'
  },
  gallery : {
    textAlign: 'center',
    marginTop: 10,
    marginBottom: 30,
    fontSize: 28,
    fontWeight: 'bold',
  },
  button_container: {
    alignItems: 'center',
    height: 50,
    marginTop: 30,
    marginBottom: 30
  },
  button: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-around',
    width: '70%',
    paddingHorizontal: 20,
    borderRadius: 8,
    backgroundColor: '#35bbb4',
  },
  text_button: {
    textAlign: 'center',
    fontSize: 18,
    fontWeight: 'bold',
    letterSpacing: 0.55,
    color: 'white',
  },
});

function onClick () {
  console.log('Button Press');
}

export default connect(
  state => ({...state.photo}), ({...actionCreator})
)(Photo);