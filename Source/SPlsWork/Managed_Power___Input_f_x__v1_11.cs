using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_MANAGED_POWER___INPUT_F_X__V1_11
{
    public class UserModuleClass_MANAGED_POWER___INPUT_F_X__V1_11 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_TRANSLATION_TO_ZERO;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> X;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> X_PARAMETER;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> Y;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FUNCTION_OF_X;
        ushort GNINITCOMPLETE = 0;
        object X_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort NLMAI = 0;
                ushort NINDEX = 0;
                
                
                __context__.SourceCodeLine = 28;
                NLMAI = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 30;
                if ( Functions.TestForTrue  ( ( GNINITCOMPLETE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 32;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (X[ NLMAI ] .UshortValue == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 34;
                        FUNCTION_OF_X [ NLMAI]  .Value = (ushort) ( Y[ 1 ] .UshortValue ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 38;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 2 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)33; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( NINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NINDEX  >= __FN_FORSTART_VAL__1) && (NINDEX  <= __FN_FOREND_VAL__1) ) : ( (NINDEX  <= __FN_FORSTART_VAL__1) && (NINDEX  >= __FN_FOREND_VAL__1) ) ; NINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 40;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (X[ NLMAI ] .UshortValue == X_PARAMETER[ NINDEX ] .UshortValue))  ) ) 
                                {
                                __context__.SourceCodeLine = 41;
                                break ; 
                                }
                            
                            __context__.SourceCodeLine = 38;
                            } 
                        
                        __context__.SourceCodeLine = 43;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NINDEX <= 33 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 45;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Y[ NINDEX ] .UshortValue ) || Functions.TestForTrue ( ENABLE_TRANSLATION_TO_ZERO  .Value )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 47;
                                FUNCTION_OF_X [ NLMAI]  .Value = (ushort) ( Y[ NINDEX ] .UshortValue ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 50;
                            if ( Functions.TestForTrue  ( ( ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO  .Value)  ) ) 
                                { 
                                __context__.SourceCodeLine = 52;
                                FUNCTION_OF_X [ NLMAI]  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 60;
            GNINITCOMPLETE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 61;
            GNINITCOMPLETE = (ushort) ( Functions.Not( WaitForInitializationComplete() ) ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        ENABLE_TRANSLATION_TO_ZERO = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_TRANSLATION_TO_ZERO__DigitalInput__, this );
        m_DigitalInputList.Add( ENABLE_TRANSLATION_TO_ZERO__DigitalInput__, ENABLE_TRANSLATION_TO_ZERO );
        
        ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO__DigitalInput__, this );
        m_DigitalInputList.Add( ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO__DigitalInput__, ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO );
        
        X = new InOutArray<AnalogInput>( 1, this );
        for( uint i = 0; i < 1; i++ )
        {
            X[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( X__AnalogSerialInput__ + i, X__AnalogSerialInput__, this );
            m_AnalogInputList.Add( X__AnalogSerialInput__ + i, X[i+1] );
        }
        
        X_PARAMETER = new InOutArray<AnalogInput>( 33, this );
        for( uint i = 0; i < 33; i++ )
        {
            X_PARAMETER[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( X_PARAMETER__AnalogSerialInput__ + i, X_PARAMETER__AnalogSerialInput__, this );
            m_AnalogInputList.Add( X_PARAMETER__AnalogSerialInput__ + i, X_PARAMETER[i+1] );
        }
        
        Y = new InOutArray<AnalogInput>( 33, this );
        for( uint i = 0; i < 33; i++ )
        {
            Y[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( Y__AnalogSerialInput__ + i, Y__AnalogSerialInput__, this );
            m_AnalogInputList.Add( Y__AnalogSerialInput__ + i, Y[i+1] );
        }
        
        FUNCTION_OF_X = new InOutArray<AnalogOutput>( 1, this );
        for( uint i = 0; i < 1; i++ )
        {
            FUNCTION_OF_X[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FUNCTION_OF_X__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( FUNCTION_OF_X__AnalogSerialOutput__ + i, FUNCTION_OF_X[i+1] );
        }
        
        
        for( uint i = 0; i < 1; i++ )
            X[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( X_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_MANAGED_POWER___INPUT_F_X__V1_11 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint ENABLE_TRANSLATION_TO_ZERO__DigitalInput__ = 0;
    const uint ENABLE_UNKNOWN_X_TRANSLATION_TO_ZERO__DigitalInput__ = 1;
    const uint X__AnalogSerialInput__ = 0;
    const uint X_PARAMETER__AnalogSerialInput__ = 1;
    const uint Y__AnalogSerialInput__ = 34;
    const uint FUNCTION_OF_X__AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
